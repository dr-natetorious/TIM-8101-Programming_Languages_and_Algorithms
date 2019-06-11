FROM hortonworks/sandbox-hdp-standalone
LABEL Author="Nate Bachmeier"
LABEL Course="TIM-8110: Programming Languages and Algorithms"
LABEL School="NorthCentral University"

# # Install core binaries
# RUN apt-get -y update && apt-get -y install \
#   default-jdk \
#   git \
#   zip \
#   awscli \
#   nano \
#   make

# # Setup the class path so everything is found by default
# # To run the javacc utility use a command like
# #     java javacc -OUTPUT_DIRECTORY=/src/out /src/LDK/Lexer/NCU_PL.jj
# ENV CLASSPATH=.:/src/javacc-6.0/bin/lib/javacc.jar

# # The build.sh script uses the value to output build artifacts
# ENV OUTPUT_DIRECTORY=/src/out/

# # Setup Remote Debugger from the container
# # Start the debugger with command like
# #   java -Xdebug -Xrunjdwp:transport=dt_socket,server=y,address=5005,suspend=y NCU_PL_Lexer_Driver {filename}
# #EXPOSE 5005