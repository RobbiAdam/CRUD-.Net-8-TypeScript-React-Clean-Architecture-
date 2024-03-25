import { Button } from "semantic-ui-react";
import { EmployeeDto } from "../../models/employeeDto"
import apiConnector from "../../api/apiConnector";
import { NavLink } from "react-router-dom";

interface Props {
    employee: EmployeeDto;
} 
export default function EmployeeTableItem({employee}: Props) {
    return (
        <>
            <tr className=" center aligned">
                <td data-label="Id">{employee.id}</td>
                <td data-label="Name">{employee.name}</td>
                <td data-label="Age">{employee.age}</td>                
                <td data-label="Department">{employee.department}</td>
                <td data-label="Contract Type">{employee.contractType}</td>
                <td data-label="Employee Grade">{employee.employeeGrade}</td>
                <td data-label="Created Date">{employee.createdDate}</td>
                <td data-label="Action">
                    <Button as={NavLink} to={`editEmployee/${employee.id}`} color="green" type="submit">
                        Edit
                    </Button>
                    <Button type="button" negative onClick={async () => {
                        await apiConnector.deleteEmployee(employee.id!);
                        window.location.reload();
                    }}>Delete</Button>
                </td>
            </tr>
        </>
    );
}