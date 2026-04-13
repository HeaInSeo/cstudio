using System.Collections.Generic;
using CStudio.Core.Models;
using CStudio.DagEditAdapter;
using CStudio.Mock;

namespace CStudio.App.ViewModels;

internal static class SampleWorkspaceCatalog
{
    public static IReadOnlyList<WorkspaceShellDefinition> Create()
    {
        return
        [
            new WorkspaceShellDefinition(
                new RoleWorkspaceDescriptor(
                    RoleWorkspaceKind.PipelineAuthoring,
                    "Pipeline Authoring",
                    "Author",
                    "#8FD3A9",
                    "DagEdit-backed pipeline editing workspace"),
                DagEditShellFactory.CreateSample()),
            new WorkspaceShellDefinition(
                new RoleWorkspaceDescriptor(
                    RoleWorkspaceKind.PipelineAnalysis,
                    "Pipeline Analysis",
                    "Analyze",
                    "#8CA6D8",
                    "Report inspection and execution comparison workspace"),
                MockShellFactory.Create(MockWorkspaceProfiles.CreatePipelineAnalysis())),
            new WorkspaceShellDefinition(
                new RoleWorkspaceDescriptor(
                    RoleWorkspaceKind.ToolAdministration,
                    "Tool Administration",
                    "Admin",
                    "#C29EFF",
                    "Tool policy, validation, and registration workspace"),
                MockShellFactory.Create(MockWorkspaceProfiles.CreateToolAdministration())),
            new WorkspaceShellDefinition(
                new RoleWorkspaceDescriptor(
                    RoleWorkspaceKind.K8sOperations,
                    "K8s Operations",
                    "Ops",
                    "#8FD3A9",
                    "Cluster health, workload inspection, and diagnostics workspace"),
                MockShellFactory.Create(MockWorkspaceProfiles.CreateK8sOperations()))
        ];
    }
}
