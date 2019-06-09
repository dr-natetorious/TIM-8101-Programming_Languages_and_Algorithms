# Independent Readings for the Week

For this week's [Assignment](../Assignment.md) the selected topic is modeling financial markets.

This was inspired by a recent [Bloomberg article](https://www.bloomberg.com/news/articles/2019-05-21/computer-models-won-t-beat-the-stock-market-any-time-soon) which argues that it is not possible.

## Elements of the random walk

An argument is made that financial markets cannot be predicted due to being a random walk.

Rudnick describes how random walks occur in many scenarios and "plays a central role in graph theory and in the study of combinatorics, percolation theory, classical and quantum field theory and a myriad of other applications in physics and mathematics."

He uses generating function as means to construct all possible combinatorals, then applies statistical modeling to cluster nearest neighbors and their associated probability of being a final destination. The forumalas suggest that if it is possible for all of these other domains, why not also financial systems?

Rudnick, Joseph, and George Gaspari. Elements of the Random Walk : An introduction for Advanced Students and Researchers, Cambridge University Press, 2004. ProQuest Ebook Central, http://ebookcentral.proquest.com/lib/ncent-ebooks/detail.action?docID=256691.
Created from ncent-ebooks on 2019-06-09 12:43:36.

## Signal to Noise Ratios

Next a claim is made that the ticker stream has too much noise and cannot be reliably utilized.

Astronomical videos are frequently corrupted with 'impulse noise' which are bright or dark spots. These introduce challenges with edge detection and extracting similar properties. A common solution is to take averages of the different frames over time.

Aliakhmet [describes](Readings/Noise_Reduction_Astronomical_Videos.pdf) states this can be inefficient in analog systems and proposes a mechanism where:

1. Determine the intensity of each pixel
2. Find its nearest neighbors `g(x, y) = { true iff |x-y| < threshold }`
3. Construct a Similarity Matrix for each of the groups
4. Filter the frame using the Similarity Matrix
5. Apply the average value over time, ignoring filtered data points

This can be applied to financial markets as smoothing function which looks at multiple correlated products.

For example the S&P 500, contains 500 components. These could be rendered as 50 x 10 pixel frame with the intensity equal to the price or volume.

## There is insufficient data available

Next a claim is made that there is insufficient data available to accurately model financial system. They provide evidence that only 100 years of relable records are available.

Ignoring the fact that they are discounting the fact that its `100 years x assets` which makes for a significantly large dataset, the data is more recently available in micro second format. Just as days-to-years provides macro structures-- an argument can be made its also true for microsecond-to-days.

More data is also available by considering other scenarios where dynamic time series analysis occurs today. [Conditional Probability of Bombings](Readings/Dynamic_Forecasting_Bombings.pdf) is one such area, which uses time series analysis to determine the likelihood of terrorist attacks.

Li, Zhuang, and Shen used the Global Terrorism Database to first determine the types of attacks, and found that nearly 60% of them are bombings. Hijackings and hostage scenarios receive a lot of attention but are more of black swan events. Black swan events are by definition hard to predict and were eliminated as general noise. The entire dataset includes 140k attacks since 1970 (8.1/day straight average).

They show that using `Auto Regressive Moving Averages (ARMA)` and `Auto Regressive Integrated Moving Averages (ARIMA)` provide reasonably accurate fitting; however it lacks memory after `p` periods. To enhance this idea they use `Partial Auto Correlation Function (PACF)` which looks at the correlation of features within different time series.

After 9/11 attacks there is a large increase in attacks within the data set, which they model by boost the probability by a stepping function `S(t) * P(t)`. This helps to account for the increased volatility in the series and wider than normal swings.

## The edge is too small for retail customers

Next a claim is made that a trading algorithm would be looking for something that improves the odds from 50/50 to 51/49. These slight enhancements would be too small for a retail trader and would require scaling to enormous numbers of transactions. They go on to state that efficient market theory means that everything is always perfectly priced.

Dalton [describes](https://www.amazon.com/dp/B00DOSTEVG) the flaw to this argument is the discounting of `different time frames`. If a market is crashing an actor in the daily time frame would be short, versus an actor in the years+ time frame might see it as opportunity to add to their position. Similarly, a quarterly  account might sell covered calls (bets *against* their core position); as a mechansim for yield enhancement.
