import axios, { AxiosResponse } from "axios";
import { EmployeeDto } from "../models/employeeDto";
import { GetEmployeesResponse } from "../models/getEmployeesResponse";
import { GetEmployeeByIdResponse } from "../models/getEmployeeByIdResponse";
import { API_BASE_URL } from "../../config.ts";
import { formatDate } from "../utils/dateFormat";

const apiConnector = {
    getEmployees: async (): Promise<EmployeeDto[]> => {
        const response: AxiosResponse<GetEmployeesResponse> = await axios.get(`${API_BASE_URL}/employees`);
        const employees = response.data.employeeDtos.map(employee => ({
            ...employee,
            createdDate: formatDate(employee.createdDate)
        }));
        return employees;
    },

    createEmployee: async (employee: EmployeeDto): Promise<void> => {
        await axios.post(`${API_BASE_URL}/employees`, employee);
    },

    editEmployee: async (employee: EmployeeDto): Promise<void> => {
        await axios.put(`${API_BASE_URL}/employees/${employee.id}`, employee);
    },

    deleteEmployee: async (employeeId: string): Promise<void> => {
        await axios.delete(`${API_BASE_URL}/employees/${employeeId}`);
    },

    getEmployeeById: async (employeeId: string): Promise<EmployeeDto | undefined> => {
        const response = await axios.get<GetEmployeeByIdResponse>(`${API_BASE_URL}/employees/${employeeId}`);
        return response.data.employeeDto;
    }
};

export default apiConnector;
