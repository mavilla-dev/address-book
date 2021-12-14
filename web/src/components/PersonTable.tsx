import { useEffect, useState } from "react";
import { createUseStyles } from "react-jss";
import { Link } from "react-router-dom";
import { PersonUrl } from "server/EndPoints";
import { LoadState } from "server/LoadState";
import { PersonDto } from "server/PersonDto";
import { SiteTheme, useSiteTheme } from "./SiteTheme";
import { HeaderFour } from "./Typography";

type Props = {};

type Styles = "actionBar" | "table" | "row" | "fourColumnLayout";

const useStyles = createUseStyles<Styles, Props, SiteTheme>({
  actionBar: {
    alignItems: "center",
    display: "flex",
    justifyContent: "flex-end",
  },
  table: { border: "1px solid black" },
  row: {
    display: "flex",
    border: "1px solid blue",
    padding: "8px 0",
  },
  fourColumnLayout: {
    width: "25%",
  },
});

export default function PersonTable(props: Props) {
  const theme = useSiteTheme();
  const [people, setPeople] = useState<PersonDto[]>([]);
  const [loadState, setLoadState] = useState<LoadState>(LoadState.Loading);
  const styles = useStyles({ theme });

  useEffect(() => {
    fetch(PersonUrl)
      .then((response) => {
        response.json().then((data) => {
          setLoadState(LoadState.Complete);
          setPeople(data);
        });
      })
      .catch((err) => {
        setLoadState(LoadState.Error);
        console.log(err);
      });
  });

  switch (loadState) {
    case LoadState.None:
    // Intentional Fallthrough
    case LoadState.Loading:
      return <div>Loading...</div>;
    case LoadState.Complete:
      return (
        <>
          <div className={styles.actionBar}>
            <Link to="/new-person">Add New Person</Link>
          </div>
          <HeaderFour>People in book: {people.length} </HeaderFour>
          <div className={styles.table}>
            <div className={styles.row}>
              <div className={styles.fourColumnLayout}>First Name</div>
              <div className={styles.fourColumnLayout}>Last Name</div>
              <div className={styles.fourColumnLayout}>Addresses</div>
              <div className={styles.fourColumnLayout}>{/*View Link*/}</div>
            </div>
            {people.map((person, index) => {
              return (
                <div className={styles.row} key={index}>
                  <div className={styles.fourColumnLayout}>
                    {person.firstName}
                  </div>
                  <div className={styles.fourColumnLayout}>
                    {person.lastName}
                  </div>
                  <div className={styles.fourColumnLayout}>
                    {person.addressCount}
                  </div>
                  <div className={styles.fourColumnLayout}>
                    <Link to={`/address/${person.personId}`}>
                      View Addresses
                    </Link>
                  </div>
                </div>
              );
            })}
          </div>
        </>
      );
    case LoadState.Error:
      return <div>Error has occurred.</div>;
  }
}
