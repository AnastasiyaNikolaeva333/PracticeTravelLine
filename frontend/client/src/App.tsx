import styles from './App.module.scss';
import { Main } from './pages/Main';

export const App = () => {
  return (
    <div className={styles.app}>
      <Main />
    </div>
  );
};
