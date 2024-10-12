# Sqlite in-memory seems to be persisting files

Run the unit test in this repository twice. The fist time it will pass, the second time it wont, even though it's meant to be an in-memory database. It also doesn't work with this connection string:

```
Data Source=abc;mode=memory;cache=shared;
```
