import Gutter from "components/Gutter";
import PersonTable from "components/PersonTable";
import { SiteThemeColors } from "components/SiteTheme";
import { HeaderTwo } from "components/Typography";

export default function HomePage() {
  return (
    <Gutter>
      <HeaderTwo textColor={SiteThemeColors.black}>
        Welcome to the Home Page
      </HeaderTwo>
      <PersonTable />
    </Gutter>
  );
}
