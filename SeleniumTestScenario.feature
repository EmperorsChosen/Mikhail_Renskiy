Feature: AddNewWorkShift

Scenario: AddWorkShift
Given User logged in with data
| UserName | Password |
| Admin | admin123 |
When User click on Admin
And User click on Work Shifts
And User click on Add
And User insert data
| ShiftName | AssignedEmployees |
| Shift Name   | Odis Adalwin  | 
And User click on Save
Then User delete Work Shift

