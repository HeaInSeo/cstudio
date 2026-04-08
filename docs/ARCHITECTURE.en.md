# CStudio Architecture Direction

## Summary

`cstudio` is being reframed as a Rider-style unified workstation shell.

The primary visual reference remains `GPU-Reshape/Studio`, not because of its product domain, but because its IDE-like shell structure aligns with the intended working model for `cstudio`.

## Shell Intent

`cstudio` should act as the single desktop host for multiple role-based workspaces.

The shell itself is expected to remain stable while features continue to grow inside it.

## Role-Based Workspaces

- `Pipeline Workspace`
  - graph editing
  - pipeline composition
  - run-oriented document and property surfaces
- `Admin Workspace`
  - tool authoring
  - validation
  - policy and build/register workflows
- `Operations Workspace`
  - future Kubernetes-facing monitoring and runtime inspection
  - execution diagnostics
  - environment visibility

## Reference Mapping

- `GPU-Reshape/Studio`
  - shell shape
  - docking model
  - panel hierarchy
  - IDE-style workflow
- `DagEdit`
  - pipeline canvas
  - node and edge editing semantics
- `NodeKit`
  - administrator authoring concepts
  - validation and registration flows
- `KubeUI`
  - future Kubernetes management capability area
  - not as a visual template, but as an operations-domain reference

## Product Assumption

`cstudio` should not be treated as a fixed-scope app.

Its capability set may expand significantly over time, so architecture and navigation should be designed to allow new workspaces, panels, and services without forcing a shell rewrite.

## Current Architectural Principle

Keep the shell unified, but keep feature responsibilities separated.

This means one workstation application can host multiple domains, while pipeline editing, admin authoring, and future operations logic still remain modular behind clear contracts.
