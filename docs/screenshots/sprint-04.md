# Sprint 04 Screenshot Note

## Overview

Sprint 04 replaces the mock text-only center panel with an embedded `DagEdit` editor surface.

The shell still follows the `GPU-Reshape Studio`-inspired frame, but the primary document tab now renders a real graph canvas inside `cstudio`.

## Preview

![Sprint 04 shell preview](assets/sprint-04-shell-preview.svg)

## Visual Signals For This Sprint

- `Dag Canvas` becomes the first document tab
- the center document region shows a live embedded graph editor
- the canvas header exposes node and link counts
- diagnostic tabs remain available beside the embedded editor

## Notes

- this sprint embeds the editor surface, but does not yet fully synchronize in-canvas interaction back into every shell panel
- selection-flow hardening moves to Sprint 05

## Status

Completed and published to GitHub.
