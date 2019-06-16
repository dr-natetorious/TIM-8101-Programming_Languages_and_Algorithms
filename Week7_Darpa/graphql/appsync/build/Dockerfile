FROM debian:stretch
LABEL Author="Nate Bachmeier"
LABEL Course="TIM-8110: Programming Languages and Algorithms"
LABEL School="NorthCentral University"

RUN apt-get -y update \
  && apt-get -y install \
    default-jdk-headless \
    maven \
    subversion

WORKDIR /svn
RUN svn checkout http://svn.apache.org/repos/asf/velocity/engine/trunk velocity

WORKDIR /svn/velocity
RUN mvn