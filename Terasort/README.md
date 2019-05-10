# Terasort Benchmark

Generate 1TB of random data and sort it as fast as you can.

## Starting teragen

```bash
examples=/usr/lib/hadoop-mapreduce/hadoop-mapreduce-examples.jar
hadoop jar ${examples} teragen 100 unsorted
hadoop jar ${examples} terasort unsorted sorted
hadoop jar ${examples} teravalidate sorted results
```

## Accessing EMR Web Portal




Download PuTTY.exe to your computer from:
http://www.chiark.greenend.org.uk/~sgtatham/putty/download.html
Start PuTTY.
In the Category list, click Session
In the Host Name field, type hadoop@ec2-52-12-63-233.us-west-2.compute.amazonaws.com
In the Category list, expand Connection > SSH > Auth
For Private key file for authentication, click Browse and select the private key file (taco-del-ec2.ppk) used to launch the cluster.
In the Category list, expand Connection > SSH, and then click Tunnels.
In the Source port field, type 8157 (a randomly chosen, unused local port).
Select the Dynamic and Auto options.
Leave the Destination field empty and click Add.
Click Open.
Click Yes to dismiss the security alert.