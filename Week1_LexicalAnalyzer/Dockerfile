FROM debian:stretch
LABEL Author="Nate Bachmeier"
LABEL Course="TIM-8110: Programming Languages and Algorithms"
LABEL School="NorthCentral University"

WORKDIR /root

# Install core binaries
RUN apt-get -y update && apt-get -y install \
  default-jdk \
  git \
  zip \
  awscli

WORKDIR /src