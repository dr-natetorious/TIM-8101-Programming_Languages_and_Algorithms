# Videos Reviewed for the Week

## Racing games - Tips and Advices (Part 1)

Viperconcepts provides [a comparative analysis](https://www.youtube.com/watch?v=xZ6i4INmISE) of beginner, amature, and professional drivers.

They evaluate the differences between their styles of driving and explain the rationals.

One of the key take aways was the criticality of `enter slow / exit fast` to efficiently go around corners.

This aligns with the initial Trial results which shows that:

1. Corners are killing reliability
2. Need more speed after the curve and into the straight away

Perhaps a rewards function should be created to encourage that behavior, then the car could go even faster.

## MIT 6.S091: Introduction to Deep Reinforcement Learning (Deep RL)

Reinforcement learning is a supervised learning algorithm that tries to guide an agent through an environment. As the agent performs actions the reward function expresses satisfaction with the behavior through numerical scores. The agent constructs a policy that maps the expected reward obtained by transitioning from one state to another.

A baby (agent) might have the objective to walk across the room (environment). During each step (action) its brain will (1) collect sensor readings (state); and (2) determining if that step moved them (a) closer to dad or (2) caused them to fall (reward function). Actions such as leaning too far forward, resulting in tipping over, are later avoided (policy). Through enough repetition (training) the baby eventually learns to complete the objective with a high degree of reliability.

In this recorded lecture Fridman, Lex provides an extensive explaination of reinforcement learning.

There is significant attention to pit-falls and best practices.

https://www.youtube.com/watch?v=zR11FLZ-O9M

![taxonomy.png](taxonomy.png)

## MIT 6.S094: Introduction to Deep Learning and Self-Driving Cars

Proposes the question is driving more like chess or communication?

Like chess would mean that it is solvable by formalized math rules; versus communication needs semantic reasoning about the evolving context.

Computers can use a similar mechanism to learn complex skills such as how to drive a car. A common pattern is to attach a camera to the front of the car and then stream each frame into a reinforcement algorithm.

The frame is converted to an array of numerical pixels with each value being assigned to an input node to a connected graph, called a neural network. The input layer is often paired with one or more hidden layers that eventually connect to an output result (e.g. desired steering angle or speed).
Each frame is traversed through the network and then uses the reward function as a mechanism to determine if the predicted action equals the desired action. Using a mathematical transform called ‘backpropagation’, the hidden layer’s edge weights (called gradients) are adjusted to improve the accuracy of future predictions.

Once the training has completed, the network will identify certain features of the image such as the centerline and edges of the track. While the computer has no concept of what these features are it does understand that certain patterns infer the desired action is left 30 degrees over right 15 degrees. These actions are then transmitted to mechanical systems the execute the state change.

There is all significant explaination on neural networks and how various scenarios are approached.

https://youtu.be/1L0TKZQcUtA

![purpose-of-layering.png](purpose-of-layering.png)
