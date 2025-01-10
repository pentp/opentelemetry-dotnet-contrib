// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

#if NET
using System.Diagnostics.CodeAnalysis;
#endif
using System.Diagnostics.Tracing;

namespace OpenTelemetry.Exporter.Geneva;

[EventSource(Name = "OpenTelemetryGenevaMetricExporter", Guid = "{edc24920-e004-40f6-a8e1-0e6e48f39d84}")]
internal sealed class MetricWindowsEventTracingDataTransport : EventSource, IMetricDataTransport
{
    private const int OtlpProtobufMetricEventId = 81;
    private bool isDisposed;

    private MetricWindowsEventTracingDataTransport()
    {
    }

    public static MetricWindowsEventTracingDataTransport Instance { get; private set; } = new();

    [NonEvent]
#if NET
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "WriteEventCore is safe when eventData object is a primitive type, which it is in this case.")]
#endif
    public unsafe void Send(MetricEventType eventType, byte[] data, int size)
    {
        EventData eventData = default;
        fixed (byte* bufferPtr = &data[sizeof(BinaryHeader)])
        {
            eventData.DataPointer = (nint)bufferPtr;
            eventData.Size = size;
            this.WriteEventCore((int)eventType, 1, &eventData);
        }
    }

    [NonEvent]
#if NET
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "WriteEventCore is safe when eventData object is a primitive type, which it is in this case.")]
#endif
    public unsafe void SendOtlpProtobufEvent(byte[] data, int size)
    {
        EventData descr = default;
        fixed (byte* blob = &data[0])
        {
            descr.DataPointer = (nint)blob;
            descr.Size = size;
            this.WriteEventCore(OtlpProtobufMetricEventId, 1, &descr);
        }
    }

#pragma warning disable CA1822 // Mark members as static

    [Event(OtlpProtobufMetricEventId)]
    public void OtlpProtobufEvent()
    {
    }

    [Event((int)MetricEventType.ULongMetric)]
    public void ULongMetricEvent()
    {
    }

    [Event((int)MetricEventType.DoubleMetric)]
    public void DoubleMetricEvent()
    {
    }

    [Event((int)MetricEventType.ExternallyAggregatedULongDistributionMetric)]
    public void ExternallyAggregatedDoubleDistributionMetric()
    {
    }

    [Event((int)MetricEventType.TLV)]
    public void TLVMetricEvent()
    {
    }

#pragma warning restore CA1822 // Mark members as static

    protected override void Dispose(bool disposing)
    {
        if (this.isDisposed)
        {
            return;
        }

        if (disposing)
        {
            // No managed resources to release.
            // The singleton instance is kept alive for the lifetime of the application.
            // Set the instance to null so that future calls to the singleton property can fail explicitly.
            Instance = null!;
        }

        this.isDisposed = true;
        base.Dispose(disposing);
    }
}
