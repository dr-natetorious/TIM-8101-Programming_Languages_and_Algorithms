# Readings for this Week

## Deep Learning Based on Lateral Control

The Open Racing Car Simulator (TORCS) is an annual contest during the IEEE World Congress on Computational Intelligence. Since 2008 it has been a reoccurring theme for attendees to demonstrate new and innovative solutions to challenges ranging from classification to computer vision.

Li et al describe a system called Multi-Task Learning (MTL) that attempts to drive a car by jointly solving N related tasks. This exploits a correlation between related challenges such that predictions are more accurate due to additional evidence. Their implementation chose tasks of (1) feature selection from camera frames; (2) optimal steering commands; and (3) classification of track curvature (e.g. left, right and straight).

Each camera frame is passed through a series of convolution layers that extract higher level constructs. For instance, the first layer might provide edge detection, the second corners and contours, the third object parts, and finally actual objects.

Deeper the network can make smarter predictions at the cost of requiring exponentially more training data. Having a reward function and classification operate on top of the extracted features enabled the researchers to reduce that requirement and improve action selection. These recommendations fed into a lateral control plane that attempts to keep the car in the lane and pointed the correct direction.

## Distributed Reinforcement Learning for Autonomous Driving

One of the challenges with reproducing the results of TORCS is that training a model is very time-consuming. To completely train a vehicle for public roads could require hundreds to thousands of billions of hours of video analysis. To process these enormous collections of videos will require new algorithms that exploit extreme levels of parallelism.

Transfer learning attempts to address these challenges by making segments of the neural network reusable. Consider the previous example where multiple convolution layers are overlaid to extract edges, object parts and then objects. If the last layer was omitted, then the network would predict object parts instead of objects. This suggests that networks for similar domains could be reusable in a different context. Clearly, not having to recompute base networks, has the potential for huge savings.

To improve the performance of calculating the shared base network, the researchers also propose a distributed architecture where N agents report to a parameter server. The server is responsible for sending work to the agents and collecting their results. When the solution is paired with economically priced cloud resources it becomes possible to run a high number of iterations rather quickly. In their scenario, 140 training hours was accomplished in 1 wall hour.

However, the parameter is a single point of failure and susceptible to being overwhelmed by the agent nodes. It might be possible to mitigate this issue by tiering the parameter servers at the cost of increased complexity merging agent results.

Another constraint is called the ‘vanishing gradient problem.’ When an agent updates the network weights it is possible for infinitely large or small values to skew the significance of a single node within the hidden layers. The likelihood is compounded by distributed agent scenarios due to sharing a global state.

## Quasi Steady-State Approach to Race Car Lap Simulation

The racing line is defined as the path that minimizes the curvature distance around the track and maximizes the gravitational speed through each corner. A racer that closely follows this line is more likely to achieve the theoretical best lap time on the course.

Quasi Steady-State (QSS) modeling can be used to approximate the line racers, by breaking the track into multiple discrete segments. Each segment is processed in parallel with the goal of optimizing the gravitational speed around the corners. Some systems leverage an even more crude approximation by using basic geometry.

Transient-optimal (TO) control systems can calculate significantly more efficient racing lines. This is accomplished by finding the optimal path with respect to the angular momentum, engine torque, tire model, and aerodynamic forces.

These additional features come at the cost of increased computing time. The journal states if calculating the QSS of a course takes 60 seconds, then TO would be on the order of 24 hours.

## Particle Swarm for Path Planning in a Racing Circuit Simulation

Bevilacqua and Starr provide a novel approach for calculating the racing line by using three minimum curved path solving algorithms. The implementation begins with encoding the track into a 2D plane of x and y coordinates. Next, the track was broken into a collection of waypoints with each independently measured by the solvers.

At each step, the results of the different algorithms are compared, and the most efficient route selected. The first solver uses the QSS approach, and the others introduce the idea of a Genetic Algorithm and Particle Swarming.

An analogy for their generic algorithm would be to deal cards and then chose the best poker hands. The best hands are reshuffled and redealt while the worst hands are omitted from the deck. They continue ‘shuffling the route parameters’ until the ‘best hand’ converges and expresses the optimal route.

The third approach used particle swarming to express a graph that represents the available paths to the next waypoint. Though a Monte Carlo simulation different paths are chosen and the weights between the nodes updated to reflect the required time to traverse. After enough iterations, the most efficient path is equal to the shortest distance across the particle graph.
