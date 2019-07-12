
An automation framework to automate a simple (real world ish) website. We have a website that displays a list of predicted proteins and their sizes that have been calculated using various techniques such as Analytical ultracentrifugation, Dynamic light scattering, Gel electrophoresis etc depending on the size of the proteins... The results have been parsed through various machine learning agents (multi-agent deep reinforcement learning) to take the results from the physical test and predict the protein more accurately than the simple result would dictate.

The site consists of three pages where the user would select a protein sample, a AI algorithm type and the predicted data that is returned. Note: due to the predictive algorithm the data returned is nondeterministic, so will change each time it is calculated within tolerance. The demonstration algorithm in this sample site will also be used as seed training data for the actual predictive model but can also act as a simulation for the actual model.

To use the ChromeDriver
1. Update to the latest Chrome or Edge
2. Update the Chromedriver/Edge driver (via nuget) to match the browser