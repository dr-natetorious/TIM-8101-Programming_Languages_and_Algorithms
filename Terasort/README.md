# Terasort Benchmark

This initial test involved 1GB of data.

The below commands assume that this variable is set `examples=/usr/lib/hadoop-mapreduce/hadoop-mapreduce-examples.jar`

## Starting terasort

```bash
[hadoop@ip-172-31-24-88 ~]$ history
    1  examples=/usr/lib/hadoop-mapreduce/hadoop-mapreduce-examples.jar
   14  hadoop jar ${examples} teragen 100 unsorted
   15  hdfs dfs -ls
   16  hdfs dfs -ls unsorted
   18  hadoop jar ${examples} terasort unsorted/ taco/
   21  hadoop jar ${examples} teravalidate taco/ results/
   24  hdfs dfs -ls results/
   25  hdfs dfs -cat  results/part-r-00000
```

## Running TeraGen

This execution generated 1.0 GB of random data into the output directory `unsorted-gb2`.

It took roughly 30 seconds on default 1 node EMR cluster (c3.xlarge).

```log
[hadoop@ip-172-31-24-88 unsorted]$ hadoop jar ${examples} teragen 10000000 unsorted-gb2
19/05/10 03:28:31 INFO client.RMProxy: Connecting to ResourceManager at ip-172-31-24-88.us-west-2.compute.internal/172.31.24.88:8032
19/05/10 03:28:31 INFO terasort.TeraGen: Generating 10000000 using 4
19/05/10 03:28:31 INFO mapreduce.JobSubmitter: number of splits:4
19/05/10 03:28:31 INFO mapreduce.JobSubmitter: Submitting tokens for job: job_1557457832976_0006
19/05/10 03:28:32 INFO impl.YarnClientImpl: Submitted application application_1557457832976_0006
19/05/10 03:28:32 INFO mapreduce.Job: The url to track the job: http://ip-172-31-24-88.us-west-2.compute.internal:20888/proxy/applicat
19/05/10 03:28:32 INFO mapreduce.Job: Running job: job_1557457832976_0006
19/05/10 03:28:39 INFO mapreduce.Job: Job job_1557457832976_0006 running in uber mode : false
19/05/10 03:28:39 INFO mapreduce.Job:  map 0% reduce 0%
19/05/10 03:28:50 INFO mapreduce.Job:  map 50% reduce 0%
19/05/10 03:28:59 INFO mapreduce.Job:  map 75% reduce 0%
19/05/10 03:29:00 INFO mapreduce.Job:  map 100% reduce 0%
19/05/10 03:29:00 INFO mapreduce.Job: Job job_1557457832976_0006 completed successfully
19/05/10 03:29:00 INFO mapreduce.Job: Counters: 32
        File System Counters
                FILE: Number of bytes read=0
                FILE: Number of bytes written=678128
                FILE: Number of read operations=0
                FILE: Number of large read operations=0
                FILE: Number of write operations=0
                HDFS: Number of bytes read=337
                HDFS: Number of bytes written=1000000000
                HDFS: Number of read operations=16
                HDFS: Number of large read operations=0
                HDFS: Number of write operations=8
        Job Counters
                Killed map tasks=1
                Launched map tasks=4
                Other local map tasks=4
                Total time spent by all maps in occupied slots (ms)=1527856
                Total time spent by all reduces in occupied slots (ms)=0
                Total time spent by all map tasks (ms)=34724
                Total vcore-milliseconds taken by all map tasks=34724
                Total megabyte-milliseconds taken by all map tasks=48891392
        Map-Reduce Framework
                Map input records=10000000
                Map output records=10000000
                Input split bytes=337
                Spilled Records=0
                Failed Shuffles=0
                Merged Map outputs=0
                GC time elapsed (ms)=539
                CPU time spent (ms)=26270
                Physical memory (bytes) snapshot=1308835840
                Virtual memory (bytes) snapshot=12695109632
                Total committed heap usage (bytes)=983564288
        org.apache.hadoop.examples.terasort.TeraGen$Counters
                CHECKSUM=21472776955442690
        File Input Format Counters
                Bytes Read=0
        File Output Format Counters
                Bytes Written=1000000000
```

### Terasort

```bash
[hadoop@ip-172-31-24-88 unsorted]$ hadoop jar ${examples} terasort unsorted-gb2/ sorted-gb2/
19/05/10 03:30:18 INFO terasort.TeraSort: starting
19/05/10 03:30:19 INFO input.FileInputFormat: Total input files to process : 4
Spent 148ms computing base-splits.
Spent 2ms computing TeraScheduler splits.
Computing input splits took 150ms
Sampling 8 splits of 8
Making 1 from 100000 sampled records
Computing parititions took 560ms
Spent 713ms computing partitions.
19/05/10 03:30:20 INFO client.RMProxy: Connecting to ResourceManager at ip-172-31-24-88.us-west-2.compute.internal/172.31.24.88:8032
19/05/10 03:30:20 INFO mapreduce.JobSubmitter: number of splits:8
19/05/10 03:30:20 INFO mapreduce.JobSubmitter: Submitting tokens for job: job_1557457832976_0007
19/05/10 03:30:21 INFO impl.YarnClientImpl: Submitted application application_1557457832976_0007
19/05/10 03:30:21 INFO mapreduce.Job: The url to track the job: http://ip-172-31-24-88.us-west-2.compute.internal:20888/proxy/applicat                                                                                                       ion_1557457832976_0007/
19/05/10 03:30:21 INFO mapreduce.Job: Running job: job_1557457832976_0007
19/05/10 03:30:28 INFO mapreduce.Job: Job job_1557457832976_0007 running in uber mode : false
19/05/10 03:30:28 INFO mapreduce.Job:  map 0% reduce 0%
[hadoop@ip-172-31-24-88 unsorted]$ hadoop jar ${examples} teragen 10000000 unsorted-gb2
19/05/10 03:28:31 INFO client.RMProxy: Connecting to ResourceManager at ip-172-31-24-88.us-west-2.compute.internal/172.31.24.88:8032
19/05/10 03:28:31 INFO terasort.TeraGen: Generating 10000000 using 4
19/05/10 03:28:31 INFO mapreduce.JobSubmitter: number of splits:4
19/05/10 03:28:31 INFO mapreduce.JobSubmitter: Submitting tokens for job: job_1557457832976_0006
19/05/10 03:28:32 INFO impl.YarnClientImpl: Submitted application application_1557457832976_0006
19/05/10 03:28:32 INFO mapreduce.Job: The url to track the job: http://ip-172-31-24-88.us-west-2.compute.internal:20888/proxy/applicat
19/05/10 03:28:32 INFO mapreduce.Job: Running job: job_1557457832976_0006
19/05/10 03:28:39 INFO mapreduce.Job: Job job_1557457832976_0006 running in uber mode : false
19/05/10 03:28:39 INFO mapreduce.Job:  map 0% reduce 0%
19/05/10 03:28:50 INFO mapreduce.Job:  map 50% reduce 0%
19/05/10 03:28:59 INFO mapreduce.Job:  map 75% reduce 0%
19/05/10 03:29:00 INFO mapreduce.Job:  map 100% reduce 0%
19/05/10 03:29:00 INFO mapreduce.Job: Job job_1557457832976_0006 completed successfully
19/05/10 03:29:00 INFO mapreduce.Job: Counters: 32
19/05/10 03:30:40 INFO mapreduce.Job:  map 25% reduce 0%
19/05/10 03:30:53 INFO mapreduce.Job:  map 50% reduce 0%
19/05/10 03:31:02 INFO mapreduce.Job:  map 75% reduce 0%
19/05/10 03:31:11 INFO mapreduce.Job:  map 88% reduce 0%
19/05/10 03:31:12 INFO mapreduce.Job:  map 100% reduce 0%
19/05/10 03:31:28 INFO mapreduce.Job:  map 100% reduce 73%
19/05/10 03:31:34 INFO mapreduce.Job:  map 100% reduce 90%
19/05/10 03:31:43 INFO mapreduce.Job: Task Id : attempt_1557457832976_0007_r_000000_0, Status : FAILED
Container killed on request. Exit code is 137
Container exited with a non-zero exit code 137
Killed by external signal

19/05/10 03:31:44 INFO mapreduce.Job:  map 100% reduce 0%
19/05/10 03:32:04 INFO mapreduce.Job:  map 100% reduce 74%
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