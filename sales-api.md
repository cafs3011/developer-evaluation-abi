\# Developer Evaluation Project



\## Getting Started



This project is a sales management API developed as part of a technical assessment using ASP.NET Core 8, DDD, Clean Code, SOLID principles, and best architectural practices.



\### Requirements

\- \[.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)

\- \[SQL Server or SQLite](https://learn.microsoft.com/en-us/sql/?view=sql-server-ver16)



---



\## How to Run the Project



1\. \*\*Clone the repository\*\*

```bash

https://github.com/your-username/developer-evaluation-sales.git

cd developer-evaluation-sales/template/backend

```



2\. \*\*Run migrations (if needed):\*\*

```bash

dotnet ef database update --project src/Ambev.DeveloperEvaluation.ORM

```



3\. \*\*Run the API:\*\*

```bash

dotnet run --project src/Ambev.DeveloperEvaluation.WebApi

```



The API will be available at:

```

https://localhost:5001 or http://localhost:5000

```



Swagger UI will also be available for testing endpoints.



---



\## Features Implemented



Sales API with the following capabilities:

\- Create, GetById, ListAll, Cancel sale

\- Calculates discounts automatically based on business rules

\- Tracks cancellation status (Cancelled / Not Cancelled)

\- Logs domain events: `SaleCreated`, `SaleCancelled`



\### Sale Fields:

\- Sale Number (auto-generated)

\- Sale Date

\- Customer

\- Branch

\- Total Amount (calculated)

\- IsCancelled (bool)

\- Products with:

&nbsp; - Quantity

&nbsp; - Unit Price

&nbsp; - Discount (auto-applied)

&nbsp; - Total per item



\### Business Rules:

\- 4–9 identical items: 10% discount

\- 10–20 identical items: 20% discount

\- > 20 identical items: \*\*not allowed\*\*

\- < 4 items: \*\*no discount\*\*



---



\## Testing



Run unit tests with:

```bash

dotnet test tests/Ambev.DeveloperEvaluation.Unit

```



The solution also contains structure for integration and functional tests.



---



\## Project Structure



\- `Domain`: Entities, specifications, events, interfaces  

\- `Application`: Use cases, commands, validators, handlers  

\- `ORM`: EF Core context, mappings, repositories  

\- `WebApi`: Controllers, DTOs, mappings, middleware  

\- `IoC`: Dependency injection modules  

\- `Tests`: Unit, Integration and Functional test projects



---



\## License

MIT or your company's license.

