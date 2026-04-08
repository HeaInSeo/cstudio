# Sprint 03 - DagEdit Adapter Pass

## Goal

Introduce the first real DagEdit-backed adapter path into the cstudio shell.

## Scope

- add a dedicated `CStudio.DagEditAdapter` project
- reference real `DagEdit` types
- build a sample `DagEditorViewModel`
- map DagEdit graph, viewport, and counts into cstudio shell contracts
- switch app composition from mock-only shell state to the DagEdit adapter path

## Done Criteria

- solution builds successfully
- cstudio composes shell services through the DagEdit adapter path
- shell documents and status regions reflect DagEdit-derived state
- GitHub-viewable screenshot note is updated

## Status

Completed.
