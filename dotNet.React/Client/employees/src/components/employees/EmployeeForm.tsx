import { ChangeEvent, useEffect, useState } from "react";
import { NavLink, useNavigate, useParams } from "react-router-dom";
import apiConnector from "../../api/apiConnector";
import { EmployeeDto } from "../../models/employeeDto";
import { Button, Form, Segment } from "semantic-ui-react";

export default function EmployeeForm() {
    const { id } = useParams();
    const navigate = useNavigate();

    const [employee, setEmployee] = useState<EmployeeDto>({
        id: undefined,
        name: "",
        age: 0,
        department: "",
        contractType: "",
        employeeGrade: "",
        createdDate: undefined
    });

    useEffect(() => {
        if (id) {
            apiConnector.getEmployeeById(id).then((employee) => {
                setEmployee(employee!)
            });
        }
    }, [id]);

    function handleSubmit() {
        if (!employee.id) {
            apiConnector.createEmployee(employee).then(() => navigate('/'));
        } else {
            apiConnector.editEmployee(employee).then(() => navigate('/'));
        }
    }
    function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
        const { name, value } = event.target;
        setEmployee({ ...employee, [name]: value });
    }

    return (
        <Segment clearing inverted>
            <Form onSubmit={handleSubmit} autoComplete="off" className="ui inverted form">
                <Form.Input placeholder='Name' name='name' value={employee.name} onChange={handleInputChange} />
                <Form.Input placeholder='Age' name='age' value={employee.age} onChange={handleInputChange} />
                <Form.Input placeholder='Department' name='department' value={employee.department} onChange={handleInputChange} />
                <Form.Input placeholder='Contract Type' name='contractType' value={employee.contractType} onChange={handleInputChange} />
                <Form.Input placeholder='Employee Grade' name='employeeGrade' value={employee.employeeGrade} onChange={handleInputChange} />
                
                <Button as={NavLink} to='/' floated='right' type='button' content='Cancel' />
                <Button floated='right' positive type='submit' content='Submit' />
            </Form>
        </Segment>
    )
}