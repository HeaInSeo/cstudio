# cstudio

`cstudio` is a Rider-style Avalonia desktop workstation shell inspired by the `GPU-Reshape` Studio UI. It is being positioned as the unified host for future pipeline editing, administrator authoring, and operations tooling rather than a narrow one-off prototype.

Korean version:

- [README.ko.md](README.ko.md)

## Current Scope

Sprint 5 is completed. Current delivered baseline:

- main window
- workspace/navigation shell
- center document host
- properties panel
- log and status regions
- adapter-ready shell contracts over mock implementations
- first DagEdit-backed adapter path
- embedded DagEdit canvas inside the center document host
- shell panels refreshed from live viewport and selection state

## Product Direction

`cstudio` is no longer treated as only a temporary shell for `DagEdit`.

It is now the candidate unified workstation for:

- pipeline authoring and graph editing
- administrator-only tool authoring and validation flows
- future Kubernetes operations and runtime inspection surfaces

The visual direction continues to follow the IDE-style shell shape learned from `GPU-Reshape/Studio`, which itself was referenced for its Rider-like working model.

## Extensibility

The functional scope of `cstudio` is expected to grow over time.

It should be treated as an extensible platform shell that can absorb additional workspaces, panels, and role-specific tools as the product expands.

## Reference

Primary UI reference:

- `GPU-Reshape/Source/UIX/Studio`

Functional/module references:

- `DagEdit`
- `NodeKit`
- `KubeUI`
- `virtualcanvas-avalonia`

## Planning

- [Roadmap (EN)](docs/ROADMAP.en.md)
- [로드맵 (KO)](docs/ROADMAP.ko.md)
- [Architecture Direction (EN)](docs/ARCHITECTURE.en.md)
- [아키텍처 방향 (KO)](docs/ARCHITECTURE.ko.md)
