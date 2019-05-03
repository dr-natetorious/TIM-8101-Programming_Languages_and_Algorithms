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

# Setup the class path so everything is found by default
# To run the javacc utility use a command like
#     java javacc -OUTPUT_DIRECTORY=/src/out /src/LDK/Lexer/NCU_PL.jj
ENV CLASSPATH=.:/src/javacc-6.0/bin/lib/javacc.jar