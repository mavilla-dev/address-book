import Gutter from "components/Gutter";
import { SiteTheme } from "components/SiteTheme";
import { Body, HeaderTwo } from "components/Typography";
import { useCallback, useState } from "react";
import { createUseStyles } from "react-jss";
import { useNavigate } from "react-router-dom";
import { PersonUrl } from "server/EndPoints";
import { LoadState } from "server/LoadState";

type Props = {};
type Styles = "inputRow" | "footer";

const useStyles = createUseStyles<Styles, Props, SiteTheme>({
  inputRow: {
    alignItems: "center",
    display: "flex",
    justifyContent: "flex-start",
  },
  footer: {
    display: "flex",
    justifyContent: "flex-end",
  },
});

export default function AddPersonPage(props: Props) {
  const styles = useStyles();
  const navigate = useNavigate();
  const [firstName, setFirstName] = useState<string>("");
  const [lastName, setLastName] = useState<string>("");
  const [loadState, setLoadState] = useState<LoadState>(LoadState.None);

  const onSubmitClick = useCallback(() => {
    setLoadState(LoadState.Loading);

    fetch(PersonUrl, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ firstName, lastName }),
    })
      .then((response) => {
        setLoadState(LoadState.None);
        if (response.status === 200) {
          navigate("/");
        }
      })
      .catch(() => {
        setLoadState(LoadState.Error);
      });
  }, [firstName, lastName, navigate]);

  const onFirstNameChange = useCallback(
    (event) => {
      setFirstName(event.target.value);
    },
    [setFirstName]
  );
  const onLastNameChange = useCallback(
    (event) => {
      setLastName(event.target.value);
    },
    [setLastName]
  );

  switch (loadState) {
    case LoadState.Error:
      return (
        <Gutter>
          <Body>Error has occurred</Body>
        </Gutter>
      );
    case LoadState.Complete:
    case LoadState.Loading:
      return (
        <Gutter>
          <Body>Submitting entry...</Body>
        </Gutter>
      );
  }

  return (
    <Gutter>
      <HeaderTwo>Add New Person</HeaderTwo>
      <div className={styles.inputRow}>
        <div>First Name:</div>
        <input onChange={onFirstNameChange} type="text" value={firstName} />
      </div>
      <div className={styles.inputRow}>
        <div>Last Name:</div>
        <input onChange={onLastNameChange} type="text" value={lastName} />
      </div>
      <div className={styles.footer}>
        <button onClick={onSubmitClick}>Submit</button>
      </div>
    </Gutter>
  );
}
