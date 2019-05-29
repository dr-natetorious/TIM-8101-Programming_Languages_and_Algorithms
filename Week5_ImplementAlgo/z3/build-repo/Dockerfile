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
RUN apt-get -y binutils g++ 
WORKDIR /git/z3prover
RUN git clone https://github.com/Z3Prover/z3 \
  && cd z3 \
  && python3 scripts/mk_make.py --python \
  && cd build \
  && make

# Running this example on Linux:
# export LD_LIBRARY_PATH=$LD_LIBRARY_PATH:MYZ3/bin
# export PYTHONPATH=MYZ3/bin/python
# python example.py

# from z3 import *

# x = Real('x')
# y = Real('y')
# s = Solver()
# s.add(x + y > 5, x > 1, y > 1)
# print(s.check())
# print(s.model())