# Independent Readings for the Week

## Cloud Migration

### Cloud_Migration_Develop_Country_Survey.pdf

This article describes the challenges that developing countries face while moving to the cloud.

Top issues include unsupportive issues, migration challenges, and conservative business cultures.

### Cloud_Migration_Strategies.pdf

This article describes the various tools that are commonly used to complete a migration to the cloud.

It describes challenges moving to cloud native platforms and the adoption of containerization as a partial solution.

### DataCenter_Migration.pdf

This article describes a successful migration from private data center into the public cloud.

The efforts were accomplished by governmental employees that oversaw 80k users.

They attribute the successes to planning, planning, and more planning.

## Max Flow and Graph Algorithms

## Comparing_Tree_Similarity.pdf

This article describes methods for evaluating the similarity of two different trees.

The author accomplishes this by looking at the edit difference between them -- similar to word differences.

### Efficient_Max_Flow_Algos.pdf

This article provides a crash course on maximum flow algorithms and all the things we forgot from undergrad.

There are several scenario specific optimizations that can be applied to find the solutions faster.

### Incremental_Max_Flow.pdf

This article describes algorithms for incrementally updating the max flow calculation without updating the entire diagram.

That behavior allows for fluid and dynamic max flow use cases with minimal computational overhead.

### MaxFlow_MinCost_BaseStations.pdf

Base stations and electrical grids are great examples where flow control appears.

Their results showed that it is more efficient to optimize for `min-cost+max-flow` over only `max-flow`.

In their specific scenario the savings were upto 35%

## Reliable Distributed Systems

### Reliable_MultiCast_under_Random_Linear_Network_Codes.pdf

This was an interesting read where RLNC is used to encode multiple messages into the same transmission.

The approach enables sending (A) and (A+B) and (B) down different channels so that receivers will likely get all 3 sets.

Having a parity bit allows for 1/3 of the messages to be missed with perfect coverage.

### DCOM_Reliability.pdf

This article describes common patterns that arrise from making distributed COM highly reliable.

This is applicable to the research topic as there is a need to have multiple decoupled components efficiently communicate together.

### Software_Defined_Networking.pdf

Software defined networks (SDN) are a layer on top of physical networking which allows for building reliable systems ontop of unreliable equipment. 

### Probabilistic_Reliability_and_Privacy_of_Communitication_Using_Multicast_in_GenNetworks.pdf

This article discusses improving reliability through crypto and game theory.

It presents a series of attack vectors within multicast scenarios and describes mitigations for multi-message sessions.

### Scalable_Eventually_Consistent_over_Lossy_Networks.pdf

This article describes a mechanism for reliably building distributed sequential counters.

Having the capability to sequentailly count exactly once sematics comes up in several scenarios.

They accomplish this through a hand shake algorithm where replicas promote tuples of (source and dest) time stamped values.

### Survey_Distributed_Transaction_Data_Partitioning.pdf

This survey provides a throughal list of methods used for distributed transactions.

## Eventing Patterns

### SagaMAS.pdf

This article describes the variations of the SAGA pattern for confirming the software oriented architecture (SOA).

The key take away was the need for implementing compensation pattern one a lower granularity is needed.

### The_Prometheus_Methodology.pdf

The deck describes a multi-agent system for defining system goals and then decomposing the functionality to meet those needs.

This enables the multi-agent system to efficiently align with a higher goal and compensate for deviation behavior. 

### Biology_Metaphores_for_EvolutionarySoftware.pdf

This article makes a detailed analysis of how software mimics biological structures.

It makes multiple comparisons to various species and object oriented patterns.

### Uncertainty_ComplexEventing_Process_Model_Validation.pdf

This article describes the patterns for creating rules to complex event processing systems.

### DCOM_and_SOAP.pdf

This article describes the differences between DCOM and SOAP.

DCOM offers more stateful features at the cost of decreased interop. These readings tie into [DCOM_Reliability.pdf](DCOM_Reliability.pdf).

## Data Integrity

### DataValidation_ETL_Using_TALEND.pdf

This was a piss poor article that proved anything can be published.

They described a vanilla model for verifying data warehouses against flat files.

### Sqli_Grammar_Reachability.pdf

The original direction of this work was around encoding vulnerabilities.

Their approach is to use grammar free static analysis which aligned well with `Week 1: JJTree` stuff

### Provable_Data_Integrity_Cloud_Storage_for_IoT.pdf

This article is centered around requirements for data integrity after the information has been uploaded to the cloud.
