# VR Petanque Workflow Policy

## Purpose
This policy defines how the Assignment 2 example work moves from an idea to a reviewed deliverable.

The current deliverables are requirements, test plans, review records, and project documentation. A playable VR game is outside the scope.

## Workflow Stages

| Stage | Purpose | Exit Condition |
|---|---|---|
| Icebox | Store ideas that are not committed to the current scope. | The idea is selected for further planning. |
| Product Backlog | Maintain prioritized work with a clear objective. | The item meets the Definition of Ready and is selected for an iteration. |
| Sprint Backlog | Identify work committed to the current iteration. | Dependencies allow work to start and WIP capacity is available. |
| In Progress | Produce or revise the deliverable. | A draft deliverable and a pull request are ready for review. |
| Testing | Check the deliverable against its acceptance criteria. | Review is complete, required corrections are made, and the pull request is merged. |
| Done | Record accepted and merged work. | Evidence links are attached and the tracking records are updated. |

## Definition of Ready
- The objective and deliverable are clear.
- Acceptance criteria are documented.
- Dependencies are identified.
- The item is small enough for the planned iteration.

## Definition of Done
- The deliverable satisfies its acceptance criteria.
- Review findings are resolved or explicitly recorded as limitations.
- The pull request is merged.
- The final document and pull request are linked from the work item.
- The tracking status reflects the actual result.

## Review Rules
For documentation tasks, Testing means checking content, requirement coverage, consistency, and applicable links.

A review performed by the author must be identified as a self-review. It is not independent approval.

Manual review must not be described as an automated test.

Game test cases remain marked Not Run when no executable game is available.

## Work in Progress
The initial In Progress limit is two work items.

This is a team policy. Tool enforcement must not be claimed unless it has been configured and verified.

When review work accumulates, prioritize finishing reviews before starting additional work.

## Traceability
- Include the Jira key in branch names, commit messages, and pull request titles.
- Link corresponding Jira and GitHub issues.
- Record the pull request and final deliverable as completion evidence.
- Do not assume Jira status, Zenhub pipeline, and GitHub Projects Status synchronize automatically.

## Tool Mapping
The six stages describe the intended comparison workflow. Each tool's actual configuration must be documented.

Until a dedicated Testing status is configured in Jira, keep the item In Progress and record that it is awaiting review in a comment.

If Zenhub provides a separate Closed pipeline, document how closure relates to Done.

## Evidence Integrity
Moving a card does not prove that the deliverable is complete.

Screenshots and activity records should show actual operations. Illustrative game scenarios must remain clearly identified as examples.
