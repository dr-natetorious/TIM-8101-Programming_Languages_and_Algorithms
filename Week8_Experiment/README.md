# Section 3: Week 8: Reproduce an Experiment

Experimentation is a vital part of research, especially when outcomes are unknown, hypotheses require testing, and claims require validation. 

In the final week of the course, you will critique and recreate a published experiment in an effort to gain a greater understanding of the methods utilized therein.

## Table of Contents

- [Assignment](Assignment.md) - Requirements for this week's deliverable.
- [Autonomous Driving Paper](Week8_AutoDriver.docx) - Essay for the the week.
- [Deep Racer Files](DeepRacer) - Notes, scripts, and related for Amazon Deep Racer.
- [Articles](Readings) - Journals read for the week
- [Videos Resources](Videos) - Videos uses to understand the content.

## Autonomous Driving

Do you know how autonomous vehicular algorithms work? I didn't which made for an interesting research topic.

I started with the [Deep Learning Based on Lateral Controls](Readings/Reinforcement_Learning_Deep_Learning_Based_Lateral_Control_for_Autonmous_Driving.pdf) article which didn't make any sense. Then I found Professor Fridman's [video lecture series](Videos) explaining neural network based algorithms.

This was applied using [Deep Racer](DeepRacer) which ran into some slight technical limitations. Back to the drawing board for more research into the strategies used by actual drivers. This led to strategies that center around the `racing line`.

It turned out that by approximating the `current position` relative to the `racing line` one can improve their laptime a fair amount.
