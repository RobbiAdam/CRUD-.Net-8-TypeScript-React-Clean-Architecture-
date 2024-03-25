import { RouteObject, createBrowserRouter } from "react-router-dom"
import App from "../App"
import EmployeeForm from "../components/employees/EmployeeForm.tsx"
import EmployeeTable from "../components/employees/EmployeeTable.tsx"

export const routes: RouteObject[] = [
{
    path: "/",
        element: <App />,
        children: [
            { path: 'createEmployee', element: <EmployeeForm key='create' /> },
            { path: 'editEmployee/:id', element: <EmployeeForm key='edit' /> },
            { path: '*', element: <EmployeeTable /> }
        ]
    }
]

export const router = createBrowserRouter(routes)