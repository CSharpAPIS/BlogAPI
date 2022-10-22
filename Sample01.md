# Sample01 for LINQ

- 01

```csharp
var customers = new int[]{ 1, 9, 0, 9, 9, 4, 2, 3, 20, 45 };
            var queryAllCustomers = from cust in customers
                                    where cust < 40 && cust != 0
                                    orderby cust descending
                                    group cust by cust % 2 == 0.0 into custGroup
                                    where custGroup.Any()
                                    orderby custGroup.Key
                                    select custGroup;
```

<hr/>

