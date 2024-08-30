# Kafka .NET Sample Project

This repository contains a basic setup for working with Apache Kafka using .NET 8. It includes a Dockerized Kafka environment and two .NET applications: a producer and a consumer. These applications demonstrate how to produce and consume messages in Kafka using .NET.

## Table of Contents

- [Project Structure](#project-structure)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
  - [1. Clone the Repository](#1-clone-the-repository)
  - [2. Start Kafka Environment](#2-start-kafka-environment)
  - [3. Build and Run the Producer](#3-build-and-run-the-producer)
  - [4. Build and Run the Consumer](#4-build-and-run-the-consumer)
- [Docker Compose Overview](#docker-compose-overview)
- [Extending the Logic](#extending-the-logic)
  - [Adding New Topics](#adding-new-topics)
  - [Handling Different Data Types](#handling-different-data-types)
  - [Scaling Out](#scaling-out)
  - [Integration with Other Services](#integration-with-other-services)
- [Accessing the Kafka UI](#accessing-the-kafka-ui)
- [Stopping the Environment](#stopping-the-environment)

## Project Structure

- **Kafka Consumer**
  - A .NET 8 application that consumes messages from a Kafka topic.
- **Kafka Producer**
  - A .NET 8 application that produces messages to a Kafka topic.
- **docker-compose.yml**
  - A Docker Compose file that sets up a local Kafka environment, including a Kafka broker and Zookeeper.

## Prerequisites

- .NET 8 SDK installed on your machine.
- Docker and Docker Compose installed on your machine.

## Getting Started

### 1. Clone the Repository

```bash
git clone <repository-url>
cd <repository-directory>
```

### 2. Start Kafka Environment

To start the Kafka environment, use Docker Compose:

```bash
docker-compose up -d
```

This will start the Kafka broker and Zookeeper, making Kafka available locally on the default ports.

### 3. Build and Run the Producer

Navigate to the Kafka Producer directory and build the application:

```bash
cd "Kafka Producer"
dotnet build
dotnet run
```

The producer application will start and begin sending messages to the specified Kafka topic.

### 4. Build and Run the Consumer

In a new terminal, navigate to the Kafka Consumer directory and build the application:

```bash
cd "Kafka Consumer"
dotnet build
dotnet run
```

The consumer application will start and begin consuming messages from the specified Kafka topic.

## Docker Compose Overview

The docker-compose.yml file is responsible for setting up the necessary infrastructure to run Kafka locally.

- **Zookeeper** starts first, providing the necessary coordination service.
- **Kafka** starts after Zookeeper and connects to it, forming the Kafka cluster.
- Your .NET applications (producer and consumer) interact with the Kafka broker, producing and consuming messages as needed.

## Extending the Logic

### Adding New Topics

- Update the producer and consumer code to reference the new topic(s).
- Ensure the new topic is created in Kafka. You can create topics using Kafka CLI tools or programmatically in the .NET applications.

### Handling Different Data Types

- Modify the producer to serialize different data types into Kafka messages.
- Adjust the consumer to deserialize and handle these different data types accordingly.

### Scaling Out

- Multiple Consumers: You can run multiple instances of the consumer to scale out message processing.
- Partitioning: Kafka topics can be partitioned to allow parallel processing of messages by multiple consumers.

### Integration with Other Services

- Extend the producer or consumer to integrate with other systems, such as databases or external APIs, by modifying the business logic in the .NET applications.

## Accessing the Kafka UI

This project includes a Kafka UI tool to help you manage and monitor your Kafka environment. The Kafka UI allows you to view topics, partitions, consumer groups, and more through a web interface.

### Access the Kafka UI:

Access the UI in Your Browser: Once the Kafka environment is running, open your web browser and navigate to the following URL:

```bash
http://localhost:8080
```

This will bring up the Kafka UI, where you can manage topics, inspect messages, and monitor your Kafka brokers and consumer groups.

### Navigating the UI:

Topics: View and manage your Kafka topics.
Consumers: Monitor consumer groups and their offsets.
Brokers: View the status and details of your Kafka brokers.

## Stopping the Environment

To stop and remove the Kafka containers, use:

```bash
docker-compose down
```
