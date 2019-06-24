# Section 3: Week 7: Develop a Research Proposal

This week focuses on the development of a research proposal for a DARPA grant.

## Table of Contents

- [DAPRA Proposal](Week7_Darpa.docx) - Research Proposal to improve reliability of cloud data ingestion scenarios.
- [Readings](Readings) - Bibliography of independent readings for the week.
- [Assignment](Assignment.md) - Requirements of this weeks research material.
- [GraphQL](graphql) - Individual research was performed on graphql and Amazon appsync
- [DARPA](darpa) - The Assignment requires writing a DARPA proposal, notes from investigating existing samples

## Proposal Abstract

Contoso is a provider of online student analytic services with a vast collection of micro- services hosted in their private data center. A tenant of micro-service design states that each component should ‘share-nothing’ including data stores. This reduces the blast radius and improves the resiliency of the overall system.

They need a mechanism to efficiently transition their product lines from private data centers into the public cloud. These heterogeneous private stores can introduce challenges for that migration as they need to become hydrated afterward. Substantial amounts of literature exist for trivial ‘lift and shift’ paradigms upon an individual store, however, less research has taken place on reliably hydrating networks of integrated data stores.

Additional thought and consideration is applied to generically building reliable ingestion systems by leveraging state-of-the-art approaches from other sciences.
