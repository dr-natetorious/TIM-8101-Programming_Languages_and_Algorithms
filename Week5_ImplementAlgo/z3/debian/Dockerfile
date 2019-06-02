FROM debian:stretch
LABEL Author="Nate Bachmeier"
LABEL Course="TIM-8110: Programming Languages and Algorithms"
LABEL School="NorthCentral University"

# Install core binaries
RUN apt-get -y update && apt-get -y install \
  default-jdk \
  git \
  zip \
  awscli \
  nano \
  make

# Get the sources for z3...
RUN apt-get -y install binutils g++ 
WORKDIR /git/z3prover
RUN git clone https://github.com/Z3Prover/z3 \
  && cd z3 \
  && python3 scripts/mk_make.py --python \
  && cd build \
  && make \
  && make install

# Install Remote Debugger...
RUN apt-get -y install python3-pip \
  && pip3 install ptvsd

EXPOSE 5678
