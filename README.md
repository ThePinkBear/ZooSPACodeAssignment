# Zoo Fullstack CodeAssignment

## This application is run in Localhost

- Ensure you have .Net 8.0 SDK to run the backend.
- Ensure you have the latest version of Node for the frontend.

When the repo is cloned open a terminal in the root of the project and run:

```bash
dotnet restore
dotnet build
dotnet test
```

If all tests are green run:

```bash
cd ZooBackend
dotnet watch run
```

*This will test and start the backend of the application, it will also open swagger in your native browser where you can inspect the endpoints and their return values.*

**Open a new terminal in the root of the project:**

```bash
cd ZooFrontEnd
npm i
npm run dev
```

*The terminal will point at a localhost address, cmd or ctrl click the link in the terminal and you will see the application.*
