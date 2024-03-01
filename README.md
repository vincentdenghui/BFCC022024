# Calculator App

## Usage


```sh
GET /calculator/<operation>?operandA=<numberA>&operandB=<numberB>
```
operation: "add", "subtract", "multiply" and "divide"
numberA: string representation of a double-precision floating-point number.
numberB: string representation of a double-precision floating-point number.

Sample request:
```sh
    GET /calculator/add?operandA=1&operandB=2
```

returns "3"
    
## Edge cases
Invalid operator will cause a 400 BadRequest response.
Any invalid number will cause a 400 BadRequest response.
Missing of any number or operator will cause a 400 BadRequest response.
Divisions by zero return "∞".