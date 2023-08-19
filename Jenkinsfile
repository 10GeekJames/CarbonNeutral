pipeline {
  agent any
  tools { nodejs 'NODEJS' }
  stages {
    stage('Docker Build Base') {
      steps {
        bat 'docker-compose down --remove-orphans'
        bat 'docker-compose build wordsearchkingdom-shared-base'
      }
    }
    stage('Docker Build App') {
      steps {
        bat 'docker-compose build'
      }
    }
    stage('Docker Run') {
      steps {
        bat 'docker-compose up -d'
      }
    }
  }
}
