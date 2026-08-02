# StorePilot

A lightweight, scalable desktop retail management system for small and
medium businesses, built with **C#, WinForms, SQLite, and ADO.NET**.

> **Status:** Active Development

---

## Overview

StorePilot is a desktop management system built for a plumbing supply
retail business, developed as a direct evolution of an earlier client
project ([AutoParts Pro](https://github.com/AbdulrahmanFrontend/AutoParts-Pro)).
It carries forward the same core retail workflow while applying a
redesigned schema and stronger data-integrity patterns based on lessons
learned from that first project.

---

## Features

- Inventory management
- Sales and purchase invoicing
- Customer and supplier account management
- Payment tracking
- Sales returns
- Cash management
- Invoice printing
- Automated backup
- SQLite local database with automatic initialization

---

## What's Different From My First Project

StorePilot's schema and data layer were redesigned from the ground up to
fix issues identified in earlier work:

| Area | Approach |
|---|---|
| Currency fields | `decimal` throughout (not `float`/`double`) to avoid rounding errors on financial data |
| Cancelling records | Soft-cancel (status flag) instead of hard delete, preserving a full audit trail |
| Invoices | A single unified `Invoices` table with extension tables for purchases and sales, instead of duplicated logic across two separate models |
| Transactions | Transaction-aware DAL methods that can run standalone or as part of a caller-supplied transaction, with explicit commit/rollback control |

---

## Technology Stack

| Category | Technology |
|---|---|
| Language | C# |
| Framework | .NET Framework |
| UI | Windows Forms |
| Database | SQLite |
| Data Access | ADO.NET |
| Shared Infrastructure | [DevToolkit](https://github.com/AbdulrahmanFrontend/DevToolkit) |
| Architecture | Layered (UI / BLL / DAL / Core) |

---

## Project Structure

Presentation (WinForms)
│
Business Logic Layer
│
Data Access Layer (transaction-aware)
│
SQLite Database

---

## Database

The database schema is scripted for reproducibility, allowing the full
SQLite structure to be recreated from source. See `Database/Scripts`.

---

## What This Project Demonstrates

- Applying lessons learned from a prior production project to a new
  schema design
- Financial data integrity (decimal precision, soft-cancel, audit trail)
- Transaction-aware data access patterns
- Building on top of a self-maintained internal library (DevToolkit)
  rather than duplicating infrastructure code

---

## Repository Notes

This repository represents the portfolio version of the project.
Client-specific information and business data are intentionally excluded.

---

## License

This repository is provided for portfolio and evaluation purposes only.
The source code may not be copied, redistributed, or used commercially
without permission.
