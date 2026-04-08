using CStudio.Core.Models;
using CStudio.Core.Services;

namespace CStudio.Mock;

public sealed class MockDocumentService : IDocumentService
{
    public IReadOnlyList<DocumentTab> GetDocuments()
    {
        return
        [
            new DocumentTab(
                "Workspace Overview",
                "Mock document",
                "CStudio Sprint 02 shell contracts.\n\nThis screen mirrors the overall information hierarchy of GPU-Reshape Studio while remaining product-neutral.\n\nThe shell no longer depends directly on mock data creation inside the main view model. Instead, it is being shifted toward adapter-ready service contracts."),
            new DocumentTab(
                "Shader: PS_GBuffer",
                "Preview",
                "float4 PS_GBuffer() : SV_Target\n{\n    float exposure = 1.0;\n    float3 albedo = float3(0.15, 0.34, 0.52);\n    return float4(albedo, exposure);\n}"),
            new DocumentTab(
                "Instrumentation Report",
                "Summary",
                "3 warnings\n1 note\n0 fatal errors\n\nNext step: replace mock shell contracts with DagEdit-backed adapters.")
        ];
    }
}
