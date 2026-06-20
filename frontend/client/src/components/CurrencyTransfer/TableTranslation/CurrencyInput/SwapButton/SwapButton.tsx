import { Button } from '../../../../Button/Button';
import styles from './SwapButton.module.scss';

type SwapButtonProps = {
  onSwap: () => void;
};

export const SwapButton = ({ onSwap }: SwapButtonProps) => {
  return <Button text={'Обменять'} additionalStyles={styles.button} onClick={onSwap} testId={'swap-button'} />;
};
