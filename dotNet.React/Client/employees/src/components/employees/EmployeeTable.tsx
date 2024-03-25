import { useEffect, useState } from "react";
import { EmployeeDto } from "../../models/employeeDto";
import apiConnector from "../../api/apiConnector";
import {Container, Button } from "semantic-ui-react";
import EmployeeTableItem from "./EmployeeTableItem";
import { NavLink } from "react-router-dom";

export default function EmployeeTable() {
    const [employees, setEmployees] = useState<EmployeeDto[]>([]);

    useEffect(() => {
        const fetchData = async () => {
            const fetchedEmployees = await apiConnector.getEmployees();
            setEmployees(fetchedEmployees);
        }
        fetchData();
    }, []);
    return (
        <>
            <Container className="container-style">
                <table className="ui inverted table">
                    <thead style={{ textAlign: "center" }}>
                        <tr>
                            <th>Id</th>
                            <th>Name</th>
                            <th>Age</th>                            
                            <th>Department</th>
                            <th>Contract Type</th>
                            <th>Employee Grade</th>
                            <th>Created Date</th>
                        </tr>
                    </thead>
                    <tbody>
                        {employees.length !== 0 && (
                            employees.map((employee, index) => (
                                <EmployeeTableItem key={index} employee={employee} />
                            ))
                        )}
                    </tbody>
                </table>
                <Button as={NavLink} to="createEmployee" floated ="right" type ="button" content ="Add Employee" positive />
            </Container>

    </>
    )
}   