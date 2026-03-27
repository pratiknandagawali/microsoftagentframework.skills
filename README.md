# Agent Skills Production (Local AI)

## Overview
This project demonstrates a production-style AI agent using:
- Microsoft Agent Framework
- Foundry Local (offline LLM)
- Modular Agent Skills

## Features
- Multi-skill architecture
- Local model execution
- Clean separation of layers

## Skills
- Finance (expense validation)
- HR (leave policies)
- Data (analysis)
- Docs (summarization)

## Run

1. Start Foundry:
   foundry serve

2. Run API:
   dotnet run --project src/Api

3. Test API:
   POST /api/agent
