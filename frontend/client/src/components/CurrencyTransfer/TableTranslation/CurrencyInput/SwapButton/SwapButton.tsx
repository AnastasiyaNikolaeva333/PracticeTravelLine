import { Button } from '../../../../Button/Button';
import styles from './SwapButton.module.scss';

type SwapButtonProps = {
  onSwap: () => void;
  testId?: string;
};

export const SwapButton = ({ onSwap, testId }: SwapButtonProps) => {
  return <Button text={'Обменять'} additionalStyles={styles.button} onClick={onSwap} testId={testId} />;
};
