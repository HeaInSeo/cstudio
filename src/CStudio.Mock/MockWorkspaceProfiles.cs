using CStudio.Core.Models;

namespace CStudio.Mock;

public static class MockWorkspaceProfiles
{
    public static MockWorkspaceProfile CreateDefault()
    {
        WorkspaceNode[] workspaceNodes =
        [
            new("Workspace", ["Overview", "Launch Config", "Recent Sessions"]),
            new("Pipelines", ["FrameGraph/Main", "Lighting/Resolve", "Post/ToneMap"]),
            new("Shaders", ["VS_Main", "PS_GBuffer", "CS_BloomDownsample"]),
            new("Reports", ["Instrumentation", "Validation", "Messages"]),
        ];

        DocumentTab[] documents =
        [
            new(
                "Workspace Overview",
                "Mock document",
                "CStudio Sprint 02 shell contracts.\n\nThis screen mirrors the overall information hierarchy of GPU-Reshape Studio while remaining product-neutral.\n\nThe shell no longer depends directly on mock data creation inside the main view model. Instead, it is being shifted toward adapter-ready service contracts."),
            new(
                "Shader: PS_GBuffer",
                "Preview",
                "float4 PS_GBuffer() : SV_Target\n{\n    float exposure = 1.0;\n    float3 albedo = float3(0.15, 0.34, 0.52);\n    return float4(albedo, exposure);\n}"),
            new(
                "Instrumentation Report",
                "Summary",
                "3 warnings\n1 note\n0 fatal errors\n\nNext step: replace mock shell contracts with DagEdit-backed adapters."),
        ];

        PropertyEntry[] baseProperties =
        [
            new("Session", "Mock-Session-001"),
            new("Workspace", "RenderLab"),
            new("Backend", "Detached"),
        ];

        LogEntry[] logs =
        [
            new("INFO", "CStudio shell initialized", "09:00:01"),
            new("INFO", "Mock workspace loaded", "09:00:02"),
            new("WARN", "Runtime adapter not connected", "09:00:03"),
            new("INFO", "GPU-Reshape inspired layout active", "09:00:04"),
            new("INFO", "Sprint 02 shell contract services active", "09:00:05"),
        ];

        ShellBadge[] actionBadges =
        [
            new("Workspace", "#7B8AA6"),
            new("Documents", "#8CA6D8"),
            new("Contract Shell", "#D7BE6A"),
        ];

        string[] baseLeftStatus = ["Workspace: RenderLab", "Detached Backend", "Mode: Sprint 02"];

        ShellBadge[] rightStatus =
        [
            new("Discovery Idle", "#6E7A90"),
            new("Contracts Active", "#8CA6D8"),
            new("Sprint 02", "#D7BE6A"),
        ];

        return new MockWorkspaceProfile(
            "RenderLab",
            "GPU-Reshape Studio inspired shell",
            "Sprint 02 shell contracts / mock data",
            "RenderLab",
            "Contract-driven mock workspace",
            workspaceNodes,
            documents,
            baseProperties,
            logs,
            actionBadges,
            baseLeftStatus,
            rightStatus,
            "Detached",
            "Sprint 02");
    }

    public static MockWorkspaceProfile CreatePipelineAnalysis()
    {
        WorkspaceNode[] workspaceNodes =
        [
            new("Sessions", ["nightly-0411", "nightly-0410", "ad-hoc-debug"]),
            new("Reports", ["Frame timings", "Node diffs", "Failure clusters"]),
            new("Comparisons", ["baseline vs canary", "cpu vs gpu", "prod vs staging"]),
        ];

        DocumentTab[] documents =
        [
            new(
                "Analysis Overview",
                "Landing",
                "Pipeline analysis workspace sample.\n\nThis view is intended for inspecting execution sessions, comparing reports, and drilling into diagnostic outputs without entering authoring mode."),
            new(
                "Session Diff",
                "Comparison",
                "Changed nodes: 6\nRegression risk: medium\nFrame 218 delta: +1.8 ms\n\nNext step: pin suspicious stages and compare captured outputs."),
            new(
                "Performance Summary",
                "Metrics",
                "GPU median: 12.4 ms\nCPU median: 4.8 ms\nPeak node: Lighting/Resolve\nHot path: ToneMap -> Bloom -> Composite"),
        ];

        PropertyEntry[] baseProperties =
        [
            new("Workspace", "Pipeline Analysis"),
            new("Session", "nightly-0411"),
            new("Focus", "Report Inspection"),
        ];

        LogEntry[] logs =
        [
            new("INFO", "Analysis workspace initialized", "11:20:01"),
            new("INFO", "Session nightly-0411 attached", "11:20:02"),
            new("WARN", "2 regressions exceed 1.5 ms threshold", "11:20:03"),
            new("INFO", "Comparison summaries cached", "11:20:04"),
        ];

        ShellBadge[] actionBadges =
        [
            new("Analysis", "#78A6F0"),
            new("Reports", "#9EC2FF"),
            new("Comparison", "#D7BE6A"),
        ];

        string[] baseLeftStatus = ["Scope: nightly-0411", "Mode: inspection", "Focus: report diagnostics"];

        ShellBadge[] rightStatus =
        [
            new("2 Regressions", "#D7BE6A"),
            new("Metrics Ready", "#8FD3A9"),
            new("Read-Only", "#7B8AA6"),
        ];

        return new MockWorkspaceProfile(
            "Pipeline Analysis",
            "Inspection workspace over stable shell",
            "Analysis workspace / report inspection sample",
            "Pipeline Analysis",
            "Execution traces, reports, and comparisons",
            workspaceNodes,
            documents,
            baseProperties,
            logs,
            actionBadges,
            baseLeftStatus,
            rightStatus,
            "Analytics",
            "Analysis");
    }

    public static MockWorkspaceProfile CreateToolAdministration()
    {
        WorkspaceNode[] workspaceNodes =
        [
            new("Tools", ["dag-compile", "graph-validate", "artifact-sync"]),
            new("Policies", ["cluster-policy", "sandbox-policy", "tenant-allowlist"]),
            new("Queues", ["pending validation", "ready to register", "failed builds"]),
        ];

        DocumentTab[] documents =
        [
            new(
                "Tool Catalog",
                "Admin landing",
                "Administration workspace sample.\n\nThis area is intended for tool metadata, policy editing, build-validation cycles, and registration workflows."),
            new(
                "Registration Policy",
                "Policy",
                "Required reviewers: 2\nCluster scope: staging-first\nAllowed runtimes: dotnet, container\nRollback policy: keep previous active revision"),
            new(
                "Validation Queue",
                "Queue",
                "3 pending validations\n1 failed package\n2 waiting for schema approval"),
        ];

        PropertyEntry[] baseProperties =
        [
            new("Workspace", "Tool Administration"),
            new("Queue", "Pending Validation"),
            new("Policy Mode", "Staging First"),
        ];

        LogEntry[] logs =
        [
            new("INFO", "Administration workspace initialized", "14:05:01"),
            new("INFO", "Validation queue loaded", "14:05:02"),
            new("WARN", "artifact-sync missing schema version", "14:05:03"),
            new("INFO", "Registration policy draft opened", "14:05:04"),
        ];

        ShellBadge[] actionBadges =
        [
            new("Admin", "#C29EFF"),
            new("Validation", "#D7BE6A"),
            new("Registration", "#8FD3A9"),
        ];

        string[] baseLeftStatus = ["Scope: authoring policy", "Queue: 3 pending", "Mode: admin"];

        ShellBadge[] rightStatus =
        [
            new("Schema Drift", "#D7BE6A"),
            new("Queue Active", "#8CA6D8"),
            new("Staging First", "#8FD3A9"),
        ];

        return new MockWorkspaceProfile(
            "Tool Administration",
            "Authoring and registration workspace",
            "Administration workspace / tool policy sample",
            "Tool Administration",
            "Tool definitions, validation, and registration flows",
            workspaceNodes,
            documents,
            baseProperties,
            logs,
            actionBadges,
            baseLeftStatus,
            rightStatus,
            "Admin Shell",
            "Administration");
    }

    public static MockWorkspaceProfile CreateK8sOperations()
    {
        WorkspaceNode[] workspaceNodes =
        [
            new("Clusters", ["prod-east", "prod-west", "staging"]),
            new("Namespaces", ["pipelines", "platform", "observability"]),
            new("Workloads", ["dag-runner", "artifact-api", "ops-console"]),
        ];

        DocumentTab[] documents =
        [
            new(
                "Cluster Overview",
                "Ops landing",
                "Operations workspace sample.\n\nThis area is intended for cluster drill-down, workload health inspection, live logs, and remediation actions within the stable cstudio shell."),
            new(
                "Workload Health",
                "Health",
                "dag-runner\nReplicas: 5 / 6\nUnavailable: 1\nLast restart: 12m ago\nSuggested action: inspect failing pod logs"),
            new(
                "Recent Events",
                "Events",
                "Warning BackOff pod/dag-runner-77d49\nNormal Pulled artifact-api\nWarning FailedMount ops-console"),
        ];

        PropertyEntry[] baseProperties =
        [
            new("Workspace", "K8s Operations"),
            new("Cluster", "prod-east"),
            new("Namespace", "pipelines"),
        ];

        LogEntry[] logs =
        [
            new("INFO", "Operations workspace initialized", "16:40:01"),
            new("WARN", "dag-runner has 1 unavailable replica", "16:40:02"),
            new("INFO", "Event stream attached to prod-east", "16:40:03"),
            new("INFO", "Health panel refreshed", "16:40:04"),
        ];

        ShellBadge[] actionBadges =
        [
            new("Operations", "#8FD3A9"),
            new("Cluster", "#8CA6D8"),
            new("Diagnostics", "#D7BE6A"),
        ];

        string[] baseLeftStatus = ["Cluster: prod-east", "Namespace: pipelines", "Mode: operations"];

        ShellBadge[] rightStatus =
        [
            new("1 Replica Down", "#D7BE6A"),
            new("Stream Attached", "#8FD3A9"),
            new("Prod-East", "#8CA6D8"),
        ];

        return new MockWorkspaceProfile(
            "K8s Operations",
            "Operations workspace over IDE shell",
            "Operations workspace / cluster inspection sample",
            "K8s Operations",
            "Cluster state, workload drill-down, and diagnostics",
            workspaceNodes,
            documents,
            baseProperties,
            logs,
            actionBadges,
            baseLeftStatus,
            rightStatus,
            "Cluster Shell",
            "Operations");
    }
}
