# Sprint 05 - Interactive Shell Sync

## Goal

Reflect live state from the embedded `DagEdit` canvas back into the surrounding `cstudio` shell.

## Scope

- add a shell state service that can notify the UI when embedded canvas state changes
- feed embedded viewport movement into properties, status, and workspace chrome
- feed embedded selection changes into shell labels and diagnostics
- keep the shell contract structure reusable for future `DagEdit` integration

## UI Changes

- the workspace label now includes the active embedded selection summary
- the left status region now shows live viewport coordinates and selection kind
- the right status badges now show live scale and selection state
- the properties panel now shows selection kind, selection label, and live viewport values
- the log panel now reflects recent embedded-canvas sync events

## Done Criteria

- solution builds successfully
- shell panels react when embedded canvas viewport or selection changes
- sprint and screenshot docs clearly show the UI impact in English and Korean

## Status

Completed.
