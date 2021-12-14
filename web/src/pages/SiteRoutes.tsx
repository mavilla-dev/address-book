import SiteHeader from "components/SiteHeader";
import { Route, Routes } from "react-router-dom";
import AddAddressForPersonPage from "./AddAddressForPersonPage";
import AddPersonPage from "./AddPersonPage";
import HomePage from "./HomePage";
import ViewPersonAddressPage from "./ViewPersonAddressPage";

export default function SiteRoutes() {
  return (
    <>
      <SiteHeader />
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/new-person" element={<AddPersonPage />} />
        <Route path="/address/:personId" element={<ViewPersonAddressPage />} />
        <Route
          path="/address/:personId/new-address"
          element={<AddAddressForPersonPage />}
        />
      </Routes>
    </>
  );
}
