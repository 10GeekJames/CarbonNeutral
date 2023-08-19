FROM local:carbonneutral-shared-base
WORKDIR /

RUN apt-get update && apt-get install -y curl sudo
RUN curl -sL https://deb.nodesource.com/setup_18.x | bash - 
RUN apt-get install -y nodejs

RUN npm install -g yarn
RUN npm upgrade --global yarn
RUN npm install -g sass

# Core dependencies
RUN echo "NODE Version:" && node --version
RUN echo "NPM Version:"  && npm --version
RUN echo "YARN Version:" && yarn --version

WORKDIR /

#CMD ["sleep", "infinity"]