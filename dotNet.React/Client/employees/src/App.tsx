import { Container } from 'semantic-ui-react';
import './App.css'
import EmployeeTable from './components/employees/EmployeeTable'
import { Outlet, useLocation } from 'react-router-dom';
import { useEffect } from 'react';
import { setupErrorHandlingInterceptor } from './interceptors/axiosIntercepter';
function App() {
    const location = useLocation();

    useEffect(() => {
        setupErrorHandlingInterceptor();
    }, []);


  return (
      <>
          {location.pathname === '/' ? <EmployeeTable /> : (
          <Container className="container-style">
              <Outlet/>
              </Container>
          )}
    </>
  )
}

export default App
