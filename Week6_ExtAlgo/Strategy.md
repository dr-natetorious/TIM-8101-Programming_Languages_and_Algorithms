# Characteristics of a Strategy

Based on these initial readings there is evidence that pulling from more areas of existing science, could result in an efficient general algorithm for market participation.

## Dimensions of Profit

There are five dimensions to generating profits (alpha):

- Delta: Gains from increase in direction (eg. 1 share moves 1$ = 1 delta x 1$)
- Vega: Gains from increase in volatility (eg. expected range goes from 5$ over quarter to 15$ during same period)
- Gamma: Gains from increase in acceleration of delta (eg. an option increase in size from 50% probability to 60% probability = 50 delta becoming worth 60 delta)
- Theta: Gains from the passing of time (eg. options decay to zero and interest is charged for money lent)

Each of these dimensions can also be negative to represent being short that aspect.

An option contract posses real numbers from 0 to 100 for each of these dimensions.

## Efficient System Design

There are different optimization points for different market environments. Example market optimization points include:

- Crashing Market   (-delta,+vega,+gamma,+theta)
- Positive Trending (+delta, -vega, +gamma, 0)
- Flat Market       (0, 0, 0, +theta)

### Knapsack Problem

The classic [Knapsack Problem](https://en.wikipedia.org/wiki/Knapsack_problem) attempts to find the fewest items with the largest compensation. This is equivalent to selecting a collection of stock and options that make up a net portfolio position.

- Long Call    (+delta, +vega, +gamma, -theta)
- Long Put     (-short, +vega, +gamma, -theta)
- Long Stock   (+delta, 0, 0, dividend)
- Short Call = inverse(long call)
- Short Put  = inverse(long put)
- Short Stock  (-delta, 0, 0, -lending_fee -dividend)

### Other Optimization Requirements

The strategy might also needs to optimize for:

- Least time in market, most time as cash
- Fewest short contracts
- Highest probability of expiring worthless
- Least slippage risk

For all time frames, the strategy can be _preemptively started _before_ the large move begins.

- Being long and short
- Buying the cheaper side / selling the more expensive side
- Fire and Waiting for the assumption to be accuarate
- Setup deferred trades to fire when certain metrics occur

An alternative opinion is to _defer until after_ the large move begins.

- Easier to implement
- Less risk, less profit

### Efficient Scaling

There are two directions for scaling the net position, up or out.

Using lots of small positions gives diversity at the risk that they are difficult to call back in hast. This is more concerning for shorter time frames which need more agility. For longer time periods of several quarters to years, the added diversity could lower the impact of an individual asset to the net position.

Since the relationship exists between the diversity and timeframe, a complete algorithm needs to take this into account as well.
