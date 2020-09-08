# CleanBank
An simple Automated Teller Machine implemented with Clean Architecture.

User Requirements
- 5 users with three accounts each (checking, savings, HELOC) and a hardcoded password
--  First Name
- - Last Name
- - ID (same format as our domain users)
- - Password
- Checking account
--  Checking must always be >= 0
- Savings account
- - Max withdrawal of $500 every 24 hours
- - Savings must always be >= 0
- Loan account (HELOC) (Home Equity Line Of Credit)
- - HELOC must be <= 0
- Console application


Features:
- Login
- Balance inquiry
- - Checking, savings, HELOC
- Withdrawal
- - From checking, savings, or HELOC (increasing outstanding balance with cash)
- Deposit
- - To checking, savings, or HELOC (paying outstanding balance with cash)
- - A single deposit can have multiple destinations (in $ amount)
- Transfer funds between personal accounts
- - Checking <-> Savings
- - Checking <-> HELOC
- - Savings <-> HELOC
- Transfer funds between users
- - Checking <-> Checking
- - Savings <-> Savings
- - Checking <-> Savings
