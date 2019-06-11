FROM debian:stretch
LABEL Author="Nate Bachmeier"
LABEL Course="TIM-8110: Programming Languages and Algorithms"
LABEL School="NorthCentral University"

# Install Core System
RUN apt-get -y update \
  && apt-get -y install \
    flex \
    bison \
    cmake \
    git \
    clang \
    nano \
    python3-dev \
    python3-pip \
    googletest \
    curl \
    zip

WORKDIR /git/graphql/
RUN git clone https://github.com/graphql/libgraphqlparser.git \
  && git checkout a292268db85a4d87632ed334df026853ffa433fe \
  && git checkout -b local

WORKDIR /git/graphql/libgraphqlparser
RUN cmake . \
  && make \
  && make install

ENV GRAPHQL_PARSER_INC=/usr/local/include/graphqlparser
ENV GRAPHQL_PARSER_LIB=/usr/local/lib/

ENV CFLAGS="${CFLAGS} -I ${GRAPHQL_PARSER_INC}"
ENV LDFLAGS="${LDFLAGS} -L ${GRAPHQL_PARSER_LIB}"

# WORKDIR /git/graphql/libgraphqlparser/test
# RUN curl -L -o release-1.8.0.zip https://github.com/google/googletest/archive/release-1.8.0.zip \
#   && unzip release-1.8.0.zip \
#   && cmake . \
#   && make