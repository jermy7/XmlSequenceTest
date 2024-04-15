# Xml elements sequence serialization

Serialize and deserialize sample class. Output will looks like this

```
<?xml version="1.0" encoding="utf-8"?>
<PriceGroups xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <PriceGroup ID="1">
    <GradeID>1</GradeID>
    <Price>2310</Price>
    <GradeID>2</GradeID>
    <Price>1110</Price>
    <GradeID>3</GradeID>
    <Price>2210</Price>
    <GradeID>4</GradeID>
    <Price>1210</Price>
  </PriceGroup>
</PriceGroups>
Price Group ID: 1
Grade 1 price 2310
Grade 2 price 1110
Grade 3 price 2210
Grade 4 price 1210
```
