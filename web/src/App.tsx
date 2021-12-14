import { siteColorCodes } from "components/SiteTheme";
import SiteRoutes from "pages/SiteRoutes";
import { ThemeProvider } from "react-jss";
import { BrowserRouter } from "react-router-dom";

function App() {
  return (
    <ThemeProvider theme={siteColorCodes}>
      <BrowserRouter>
        <SiteRoutes />
      </BrowserRouter>
    </ThemeProvider>
  );
}

export default App;
