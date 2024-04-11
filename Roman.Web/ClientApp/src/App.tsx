import { useEffect, useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

function App() {
  const [companyName, setCompanyName] = useState<string>()

  useEffect(() => {
    const abortController  = new AbortController();
    fetch('/api/v1/company', {signal: abortController.signal})
      .then(response => response.text())
      .then(data => setCompanyName(data));
    
    return () => {
      abortController.abort();
    }
  }, []);
  
  return (
    <>
      <div>
        <a href="https://vitejs.dev" target="_blank">
          <img src={viteLogo} className="logo" alt="Vite logo" />
        </a>
        <a href="https://react.dev" target="_blank">
          <img src={reactLogo} className="logo react" alt="React logo" />
        </a>
      </div>
      <h1>Vite + React</h1>
      <div className="card">
       CompanyName: {companyName}
      </div>
    </>
  )
}

export default App
