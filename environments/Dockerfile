FROM alpine:3.4

ARG MYSQL_VERSION=8.0.11

RUN apk update && \
    apk add vim && \
    apk add git && \
    apk add mysql && \
    apk add curl
    
RUN curl -L -o /mysql-connector-java-${MYSQL_VERSION}.jar https://repo1.maven.org/maven2/mysql/mysql-connector-java/${MYSQL_VERSION}/mysql-connector-java-${MYSQL_VERSION}.jar
    
ENV CLASSPATH=/mysql-connector-java-${MYSQL_VERSION}.jar:${CLASSPATH}

CMD ["sh", "-c", "echo ${PATH}"]


